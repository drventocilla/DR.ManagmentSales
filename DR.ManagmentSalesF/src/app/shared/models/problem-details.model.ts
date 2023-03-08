export class ProblemDetails {

  status: number;
  type: string;
  title: string;
  detail: string;

  instance: string;
  errors: any;

  //Extensions
  indication : string;


  constructor() {

    this.status =  0;
    this.type = "";
    this.title = "";
    this.detail = "";
    this.instance = "";
    this.errors = {};
    this.indication = "";
  }
}
