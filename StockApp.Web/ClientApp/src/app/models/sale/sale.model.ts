import {ISaleGood} from "./sale-good.model";

export interface ISale {
  id: number
  goods: ISaleGood[]
}
