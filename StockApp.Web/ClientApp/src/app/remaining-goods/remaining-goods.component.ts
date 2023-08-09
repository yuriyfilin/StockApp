import {Component, OnInit} from '@angular/core';
import {IGood} from "../models/good/good.model";
import {PaginationComponent} from "../components/pagination";
import {RemainingGoodsService} from "../services/remaining-goods.service";
import {IRemainingGoods} from "../models/remaining-good/remaining-goods.model";
import {BaseResponse} from "../models/base-response.model";

@Component({
  selector: 'app-good',
  templateUrl: './remaining-goods.component.html',
})
export class RemainingGoodsComponent extends PaginationComponent implements OnInit {

  goods: IGood[] = [];
  purchaseSum: number;
  sellingSum: number;

  constructor(private remainingGoodsService: RemainingGoodsService) {
    super();

    this.loadData();
  }

  ngOnInit() {

  }

  loadData(){
    this.remainingGoodsService.getResult(this.count, this.page).subscribe((res: BaseResponse<IRemainingGoods>) => {
      console.info(res.data);
      this.goods = res.data.goods;
      this.total = res.data.total;
      this.purchaseSum = res.data.purchaseSum;
      this.sellingSum = res.data.sellingSum;
    });
  }
}
