class BankAccount {
    constructor(accountHolder, balance) {
        this.accountHolder = accountHolder;
        this.balance = balance;
    }

    deposit(amount) {
        this.balance += amount;
        console.log("Deposited:", amount);
    }

    withdraw(amount) {
        if (amount > this.balance) {
            console.log("Insufficient balance");
        } else {
            this.balance -= amount;
            console.log("Withdrawn:", amount);
        }
    }

    checkBalance() {
        console.log("Current Balance:", this.balance);
    }
}

let acc = new BankAccount("Bhargav", 5000);
acc.deposit(1000);
acc.withdraw(2000);
acc.checkBalance();