import { SysReqAdd } from "./sysreq-add.model";

export class ProductAdd{
  name: string;
  price: number;
  description: string;
  companyName: string;
  data: any;

  sysreqProduct: SysReqAdd;

  listidLang: number[];
  listidCateg: number[];



  constructor(){
    this.name = null;
    this.price = null;
    this.description = null;
    this.companyName = null;
    this.data = null;
  }

}
