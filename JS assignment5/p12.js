class Wallet {
    #balance = 0;

    addMoney(amount) {
        this.#balance += amount;
    }

    spendMoney(amount) {
        if (amount <= this.#balance) {
            this.#balance -= amount;
        } else {
            console.log("Not enough money");
        }
    }

    getBalance() {
        return this.#balance;
    }
}

let w = new Wallet();
w.addMoney(1000);
w.spendMoney(300);
console.log(w.getBalance());