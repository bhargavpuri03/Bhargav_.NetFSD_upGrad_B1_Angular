let employees = [
 { id:1, name:"Ravi", dept:"IT", salary:70000 },
 { id:2, name:"Anita", dept:"HR", salary:50000 },
 { id:3, name:"Karan", dept:"IT", salary:80000 },
 { id:4, name:"Meena", dept:"Finance", salary:60000 }
];

let totalSalary = employees.reduce((sum,e)=>sum+e.salary,0);
console.log(totalSalary);

let sorted = [...employees].sort((a,b)=>b.salary-a.salary);
console.log(sorted[0]);
console.log(sorted[sorted.length-1]);

let updated = employees.map(e =>
  e.dept === "IT"
  ? {...e, salary: e.salary*1.15}
  : e
);
console.log(updated);

let grouped = employees.reduce((acc,e)=>{
  acc[e.dept] = acc[e.dept] || [];
  acc[e.dept].push(e);
  return acc;
},{});
console.log(grouped);

let deptAvg = employees.reduce((acc,e)=>{
  acc[e.dept] = acc[e.dept] || {total:0,count:0};
  acc[e.dept].total += e.salary;
  acc[e.dept].count++;
  return acc;
},{});
for(let d in deptAvg){
  console.log(d, deptAvg[d].total/deptAvg[d].count);
}

console.log(sorted);