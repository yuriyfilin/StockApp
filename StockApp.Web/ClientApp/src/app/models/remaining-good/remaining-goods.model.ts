import {IRemainingGood} from "./remaining-good.model";

export interface IRemainingGoods {
  purchaseSum: number;
  sellingSum: number;
  total: number;
  goods: IRemainingGood[];
}
