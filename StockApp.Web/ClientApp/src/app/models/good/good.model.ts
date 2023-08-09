import {IRemainingGoods} from "../remaining-good/remaining-goods.model";

export interface IGood {
  id: number
  name: string
  vendorCode: string
  purchasePrice: number
  sellingPrice: number
  units: string
  count: number
}
