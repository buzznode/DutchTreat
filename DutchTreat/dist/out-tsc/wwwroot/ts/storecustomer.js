class StoreCustomer {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.visits = 0;
    }
    showName() {
        alert(`${this.firstName} ${this.lastName} `);
    }
    get name() {
        return this.ourName;
    }
    set name(val) {
        this.ourName = val;
    }
}
//# sourceMappingURL=storecustomer.js.map