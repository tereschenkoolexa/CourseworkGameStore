import { SysReqAdd } from "./sysreq-add.model";

export class ProductAdd{
  id: number;
  name: string;
  price: number;
  description: string;
  companyName: string;
  image: string;
  data: any;

  sysreqProduct: SysReqAdd;

  listidLang: number[];
  listidCateg: number[];

  constructor(){
    this.id = null;
    this.name = null;
    this.price = null;
    this.description = null;
    this.companyName = null;
    this.image = null;
    this.data = null;
  }

}
