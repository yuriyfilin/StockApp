import {IAcceptanceGood} from "./acceptance-good.model";

export interface IAcceptance {
  id: number
  goods: IAcceptanceGood[]
}
