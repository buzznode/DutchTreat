class StoreCustomer {

  constructor(private firstName: string, private lastName: string) {

  }

  private ourName: string;

  public visits: number = 0;

  public showName() {
    alert(`${this.firstName} ${this.lastName} `);
  }

  get name() {
    return this.ourName;
  }

  set name(val: string) {
    this.ourName = val;
  }

}
