'use strict';


const state = {
    current: '0',
    prev: null,
    operator: null,
    justCalc: false,
    lastOp: null,
    lastVal: null,
    history: [],
};


const mainEl = document.getElementById('main');
const exprEl = document.getElementById('expr');
const histPanel = document.getElementById('histPanel');
const histInner = document.getElementById('histInner');
const histEmpty = document.getElementById('histEmpty');
const histToggle = document.getElementById('histToggle');

function sanitize(n) {
    if (!isFinite(n)) return n;
    return parseFloat(parseFloat(n).toPrecision(12));
}


function formatDisplay(val) {
    const n = parseFloat(val);
    if (isNaN(n)) return val;

    if (Number.isInteger(n) && Math.abs(n) < 1e13) {
        return n.toLocaleString('az-AZ'); // minlik ayırıcısı (isteğe bağlı)
    }

    if (Math.abs(n) >= 1e13 || (Math.abs(n) < 1e-6 && n !== 0)) {
        return n.toExponential(4);
    }


    let s = parseFloat(n.toPrecision(10)).toString();
    return s;
}


function adjustFontSize(text) {
    mainEl.classList.remove('big', 'mid', 'small');
    const l = String(text).replace(/[^0-9.e+\-]/g, '').length;
    if (l <= 9) mainEl.classList.add('big');
    else if (l <= 13) mainEl.classList.add('mid');
    else mainEl.classList.add('small');
}


function setDisplay(val, isError = false) {
    mainEl.classList.remove('error', 'result-flash');

    if (isError) {
        mainEl.classList.add('error');
        mainEl.textContent = val;
        adjustFontSize(val);
        return;
    }

    const formatted = formatDisplay(val);
    mainEl.textContent = formatted;
    adjustFontSize(formatted);
}


const OP_SYMBOLS = {
    plus: '+',
    minus: '−',
    mult: '×',
    divide: '÷'
};

function setExpr(text) {
    exprEl.textContent = text || '\u00a0';
}


function highlightOp(op) {
    document.querySelectorAll('[data-op]').forEach(b => b.classList.remove('active'));
    if (op) {
        document.querySelectorAll(`[data-op="${op}"]`).forEach(b => b.classList.add('active'));
    }
}



/**
 * @returns {{ result: number|null, error: string|null }}
 */
function calculate(a, b, op) {
    const fa = parseFloat(a);
    const fb = parseFloat(b);

    if (isNaN(fa) || isNaN(fb)) {
        return {
            result: null,
            error: 'Xəta: Yanlış ədəd'
        };
    }

    let result;

    switch (op) {
        case 'plus':
            result = fa + fb;
            break;

        case 'minus':
            result = fa - fb;
            break;

        case 'mult':
            result = fa * fb;
            break;

        case 'divide':
            if (fb === 0) {

                return {
                    result: null,
                    error: 'Sıfıra bölmək olmaz!'
                };
            }
            result = fa / fb;
            break;

        default:
            return {
                result: null, error: 'Naməlum operator'
            };
    }


    result = sanitize(result);


    if (!isFinite(result)) {
        return {
            result: null,
            error: 'Xəta: Çox böyük ədəd'
        };
    }

    return {
        result,
        error: null
    };
}


function addToHistory(entry) {
    state.history.unshift(entry);
    if (state.history.length > 30) state.history.pop();
    renderHistory();
}

function renderHistory() {

    histInner.querySelectorAll('.hist-item').forEach(el => el.remove());
    histEmpty.style.display = state.history.length === 0 ? 'block' : 'none';

    state.history.forEach(h => {
        const div = document.createElement('div');
        div.className = 'hist-item';

        const [expr, res] = h.split('=').map(s => s.trim());
        div.innerHTML = `${expr} = <span class="hist-result">${res}</span>`;
        div.addEventListener('click', () => {

            state.current = res;
            state.prev = null;
            state.operator = null;
            state.justCalc = false;
            state.lastOp = null;
            state.lastVal = null;
            setDisplay(res);
            setExpr('');
            highlightOp(null);
        });
        histInner.appendChild(div);
    });
}


function inputDigit(d) {
    if (state.justCalc) {

        state.current = '0';
        state.prev = null;
        state.operator = null;
        state.justCalc = false;
        state.lastOp = null;
        state.lastVal = null;
        highlightOp(null);
        setExpr('');
    }

    if (d === '.') {

        if (state.current.includes('.')) return;
        state.current = state.current + '.';
        setDisplay(state.current);
        return;
    }

    const digits = state.current.replace('-', '').replace('.', '').length;
    if (digits >= 12) return;

    if (state.current === '0') {
        state.current = d;
    } else if (state.current === '-0') {
        state.current = '-' + d;
    } else {
        state.current = state.current + d;
    }

    setDisplay(state.current);


    if (state.operator) {
        setExpr(`${formatDisplay(state.prev)} ${OP_SYMBOLS[state.operator]}`);
    }
}


function inputOperator(op) {

    if (state.justCalc) {
        state.justCalc = false;
    }


    if (state.operator && !state.justCalc && state.prev !== null) {
        const {
            result,
            error
        } = calculate(state.prev, state.current, state.operator);
        if (error) {
            showError(error);
            return;
        }
        const resStr = String(sanitize(result));
        addToHistory(
            `${formatDisplay(state.prev)} ${OP_SYMBOLS[state.operator]} ${formatDisplay(state.current)} = ${formatDisplay(resStr)}`
        );
        state.prev = resStr;
        state.current = resStr;
        setDisplay(resStr);
    } else {

        state.prev = state.current;
    }

    state.operator = op;
    state.justCalc = false;
    highlightOp(op);
    setExpr(`${formatDisplay(state.prev)} ${OP_SYMBOLS[op]}`);
}

function doEquals() {
    if (!state.operator && state.lastOp) {

        const {
            result,
            error
        } = calculate(state.current, state.lastVal, state.lastOp);
        if (error) {
            showError(error);
            return;
        }
        const resStr = String(sanitize(result));
        const exprStr = `${formatDisplay(state.current)} ${OP_SYMBOLS[state.lastOp]} ${formatDisplay(state.lastVal)} = ${formatDisplay(resStr)}`;
        addToHistory(exprStr);
        setExpr(exprStr);
        flashResult();
        state.current = resStr;
        state.justCalc = true;
        setDisplay(resStr);
        return;
    }

    if (!state.operator || state.prev === null) return;

    const {
        result,
        error
    } = calculate(state.prev, state.current, state.operator);
    if (error) {
        showError(error);
        return;
    }

    const resStr = String(sanitize(result));
    const exprStr = `${formatDisplay(state.prev)} ${OP_SYMBOLS[state.operator]} ${formatDisplay(state.current)} = ${formatDisplay(resStr)}`;
    addToHistory(exprStr);
    setExpr(exprStr);
    flashResult();


    state.lastOp = state.operator;
    state.lastVal = state.current;

    state.current = resStr;
    state.prev = null;
    state.operator = null;
    state.justCalc = true;
    highlightOp(null);
    setDisplay(resStr);
}


function doClear() {
    state.current = '0';
    state.prev = null;
    state.operator = null;
    state.justCalc = false;
    state.lastOp = null;
    state.lastVal = null;
    highlightOp(null);
    setDisplay('0');
    setExpr('');
}

function doToggleSign() {
    if (state.current === '0') return;

    if (state.current.startsWith('-')) {
        state.current = state.current.slice(1);
    } else {
        state.current = '-' + state.current;
    }
    setDisplay(state.current);
}


function doPercent() {
    let n = parseFloat(state.current);
    if (isNaN(n)) return;

    if (state.operator && state.prev !== null) {
        const p = parseFloat(state.prev);
        if (state.operator === 'plus' || state.operator === 'minus') {

            n = sanitize(p * (n / 100));
        } else {

            n = sanitize(n / 100);
        }
    } else {
        n = sanitize(n / 100);
    }

    state.current = String(n);
    setDisplay(state.current);

    if (state.operator) {
        setExpr(`${formatDisplay(state.prev)} ${OP_SYMBOLS[state.operator]}`);
    }
}


function doDelete() {
    if (state.justCalc) {
        doClear();
        return;
    }

    if (state.current.length === 1 ||
        (state.current.length === 2 && state.current.startsWith('-'))) {
        state.current = '0';
    } else {
        state.current = state.current.slice(0, -1);
    }
    setDisplay(state.current);
}


function showError(msg) {
    setDisplay(msg, true);
    setExpr('');
    highlightOp(null);

    setTimeout(() => doClear(), 2000);
}

function flashResult() {
    mainEl.classList.add('result-flash');
    setTimeout(() => mainEl.classList.remove('result-flash'), 400);
}


function addRipple(btn, e) {
    const rect = btn.getBoundingClientRect();
    const x = e.clientX - rect.left - 30;
    const y = e.clientY - rect.top - 30;
    const ripple = document.createElement('span');
    ripple.className = 'ripple-circle';
    ripple.style.left = x + 'px';
    ripple.style.top = y + 'px';
    btn.appendChild(ripple);
    setTimeout(() => ripple.remove(), 450);
}





document.querySelectorAll('[data-num]').forEach(btn => {
    btn.addEventListener('click', e => {
        addRipple(btn, e);
        inputDigit(btn.dataset.num);
    });
});


document.querySelectorAll('[data-op]').forEach(btn => {
    btn.addEventListener('click', e => {
        addRipple(btn, e);
        inputOperator(btn.dataset.op);
    });
});


document.getElementById('btnEq').addEventListener('click', e => {
    addRipple(document.getElementById('btnEq'), e);
    doEquals();
});

document.getElementById('btnAC').addEventListener('click', e => {
    addRipple(document.getElementById('btnAC'), e);
    doClear();
});


document.getElementById('btnSign').addEventListener('click', e => {
    addRipple(document.getElementById('btnSign'), e);
    doToggleSign();
});

document.getElementById('btnPct').addEventListener('click', e => {
    addRipple(document.getElementById('btnPct'), e);
    doPercent();
});


document.getElementById('btnDel').addEventListener('click', e => {
    addRipple(document.getElementById('btnDel'), e);
    doDelete();
});

histToggle.addEventListener('click', () => {
    const isOpen = histPanel.classList.toggle('open');
    histToggle.classList.toggle('active', isOpen);
    if (isOpen) renderHistory();
});


document.addEventListener('keydown', e => {
    if (e.ctrlKey || e.metaKey || e.altKey) return;

    if (e.key >= '0' && e.key <= '9') {
        e.preventDefault();
        inputDigit(e.key);
        return;
    }
    if (e.key === '.') {
        e.preventDefault();
        inputDigit('.');
        return;
    }
    if (e.key === '+') {
        e.preventDefault();
        inputOperator('plus');
        return;
    }
    if (e.key === '-') {
        e.preventDefault();
        inputOperator('minus');
        return;
    }
    if (e.key === '*') {
        e.preventDefault();
        inputOperator('mult');
        return;
    }
    if (e.key === '/') {
        e.preventDefault();
        inputOperator('divide');
        return;
    }
    if (e.key === 'Enter' || e.key === '=') {
        e.preventDefault();
        doEquals();
        return;
    }
    if (e.key === 'Backspace') {
        e.preventDefault();
        doDelete();
        return;
    }
    if (e.key === 'Escape' || e.key === 'Delete') {
        e.preventDefault();
        doClear();
        return;
    }
    if (e.key === '%') {
        e.preventDefault();
        doPercent();
        return;
    }
    if (e.key === 'F9') {
        e.preventDefault();
        doToggleSign();
        return;
    }
    if (e.key === 'h' || e.key === 'H') {
        histToggle.click();
        return;
    }
});


setDisplay('0');
setExpr('');
renderHistory();