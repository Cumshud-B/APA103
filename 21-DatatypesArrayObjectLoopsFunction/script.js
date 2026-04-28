//task1

// function removeDuplicates(arr) {
//   const count = {};
//   arr.forEach(n => count[n] = (count[n] || 0) + 1);
//   const unique = [...new Set(arr)];
//   const duplicates = Object.entries(count)
//     .filter(([k, v]) => v > 1)
//     .map(([k, v]) => `${k} (${v} dəfə)`);
//   return { unique, duplicates };
// }

// const result = removeDuplicates([1, 2, 2, 3, 4, 3, 5]);
// console.log("Unikal array:", result.unique);
// console.log("Təkrarlar:", result.duplicates);


//task2

// function isPalindrome(str) {
//   const clean = str.toLowerCase().replace(/\s/g, '');
//   const reversed = clean.split('').reverse().join('');
//   return clean === reversed;
// }

// console.log("Task 2 - radar:", isPalindrome("radar"));   
// console.log("Task 2 - hello:", isPalindrome("hello"));   


//task3

// function countLessThan(arr, num) {
//   return arr.filter(el => el < num).length;
// }

// console.log("Task 3 - [3,7,1,9,2,8] içində 5-dən kiçik:", countLessThan([3, 7, 1, 9, 2, 8], 5)); 


//task4

// function checkAbundant(n) {
//   let sum = 0;
//   for (let i = 1; i < n; i++) {
//     if (n % i === 0) sum += i;
//   }
//   if (sum > n) return `Abundant (bölənlər cəmi: ${sum})`;
//   if (sum < n) return `Deficient (bölənlər cəmi: ${sum})`;
//   return `Perfect (bölənlər cəmi: ${sum})`;
// }

// console.log("Task 4 - 12:", checkAbundant(12));  
// console.log("Task 4 - 13:", checkAbundant(13));  



//task5


// function squareAll(arr) {
//   return arr.map(n => n ** 2);
// }

// console.log("Task 5 - [1,2,3,4,5]:", squareAll([1, 2, 3, 4, 5])); 

