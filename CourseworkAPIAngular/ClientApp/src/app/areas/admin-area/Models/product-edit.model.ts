import { SysReqAdd } from "./sysreq-add.model";

export class ProductEdit{
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

}
