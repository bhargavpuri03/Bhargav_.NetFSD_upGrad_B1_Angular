let numbers = [10, 20, 30, 10, 40, 20, 50, 60, 60];

let unique = [...new Set(numbers)];
console.log(unique);

let secondLargest = [...new Set(numbers)]
.sort((a,b)=>b-a)[1];
console.log(secondLargest);

let freq = numbers.reduce((acc,n)=>{
  acc[n] = (acc[n]||0)+1;
  return acc;
},{});
console.log(freq);

let firstNonRepeat = numbers.find(n=>freq[n]===1);
console.log(firstNonRepeat);

let rotate = numbers.slice(2).concat(numbers.slice(0,2));
console.log(rotate);

let nested = [1,2,[3,4,[5]]];
console.log(nested.flat(Infinity));

let arr = [1,2,3,5,6];
let missing = [];
for(let i=1;i<=6;i++){
  if(!arr.includes(i)) missing.push(i);
}
console.log(missing);