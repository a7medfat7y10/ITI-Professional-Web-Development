interface IAccount {
  Date_of_opening: Date;

  addCustomer(customerId: string): void;
  removeCustomer(customerId: string): void;
}

class Account {
  private Acc_no: string;
  private Balance: number;

  constructor(Acc_no: string, Balance: number) {
    this.Acc_no = Acc_no;
    this.Balance = Balance;
  }

  debitAmount(amount: number) {}

  creditAmount(amount: number) {}

  getBalance() {}
}

class Saving_Account extends Account implements IAccount {
  Date_of_opening: Date;

  constructor(Acc_no: string, Balance: number, Date_of_opening: Date) {
    super(Acc_no, Balance);
    this.Date_of_opening = Date_of_opening;
  }

  addCustomer(customerId: string) {}

  removeCustomer(customerId: string) {}
}

class Current_Account extends Account implements IAccount {
  Date_of_opening: Date;

  constructor(Acc_no: string, Balance: number, Date_of_opening: Date) {
    super(Acc_no, Balance);
    this.Date_of_opening = Date_of_opening;
  }

  addCustomer(customerId: string) {}  

  removeCustomer(customerId: string) {}
}