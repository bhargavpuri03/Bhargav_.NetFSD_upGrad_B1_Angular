let students = [
  { name: "Akhil", marks: 85 },
  { name: "Priya", marks: 72 },
  { name: "Ravi", marks: 90 },
  { name: "Meena", marks: 45 },
  { name: "Karan", marks: 30 }
];

let passed = students.filter(s => s.marks >= 40);
console.log(passed);

let distinction = students.filter(s => s.marks >= 85);
console.log(distinction);

let avg = students.reduce((sum,s) => sum + s.marks,0) / students.length;
console.log(avg);

let topper = [...students].sort((a,b)=>b.marks-a.marks)[0];
console.log(topper);

let failedCount = students.filter(s => s.marks < 40).length;
console.log(failedCount);

let grades = students.map(s => {
  let grade = s.marks >= 85 ? "A"
            : s.marks >= 60 ? "B"
            : s.marks >= 40 ? "C"
            : "Fail";
  return {...s, grade};
});
console.log(grades);