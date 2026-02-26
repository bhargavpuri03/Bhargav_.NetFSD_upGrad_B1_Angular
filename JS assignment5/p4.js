class Vehicle {
    constructor(brand, speed) {
        this.brand = brand;
        this.speed = speed;
    }

    start() {
        console.log("Vehicle started");
    }
}

class Car extends Vehicle {
    constructor(brand, speed, fuelType) {
        super(brand, speed);
        this.fuelType = fuelType;
    }

    showDetails() {
        console.log(`${this.brand} running at ${this.speed} km/h using ${this.fuelType}`);
    }
}

let c1 = new Car("Toyota", 120, "Petrol");
c1.start();
c1.showDetails();