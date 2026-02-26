class Student {
    constructor(name) {
        this.name = name;
        this.marks = [];
    }

    addMark(mark) {
        this.marks.push(mark);
    }

    getAverage() {
        let total = this.marks.reduce((a, b) => a + b, 0);
        return total / this.marks.length;
    }

    getGrade() {
        let avg = this.getAverage();
        if (avg >= 90) return "A";
        if (avg >= 75) return "B";
        if (avg >= 50) return "C";
        return "Fail";
    }
}

let s1 = new Student("Rahul");
s1.addMark(80);
s1.addMark(90);
console.log(s1.getAverage());
console.log(s1.getGrade());