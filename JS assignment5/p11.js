class User {
    set password(value) {
        if (value.length >= 6) {
            this._password = value;
        } else {
            console.log("Password must be at least 6 characters");
        }
    }

    get password() {
        return this._password;
    }
}

let u = new User();
u.password = "123456";
console.log(u.password);