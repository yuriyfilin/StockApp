import {Component, OnInit} from '@angular/core';
import {GoodService} from "../services/good.service";
import {IGood} from "../models/good/good.model";
import {PaginationResponse} from "../models/pagination-response.model";
import {PaginationComponent} from "../components/pagination";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {GoodFormComponent} from "./good-form/good-form.component";

@Component({
  selector: 'app-good',
  templateUrl: './good.component.html',
})
export class GoodComponent extends PaginationComponent implements OnInit {

  goods: IGood[] = [];

  constructor(private goodService: GoodService,
              private modalService: NgbModal) {
    super();

    this.loadData();
  }

  ngOnInit() {

  }

  loadData(){
    this.goodService.getList(this.count, this.page).subscribe((res: PaginationResponse<IGood>) => {
      console.info(res.data);
      this.goods = res.data;
      this.total = res.total;
    });
  }

  createGood() {
    const modalRef = this.modalService.open(GoodFormComponent);
    modalRef.componentInstance.successCreate.subscribe(() => {
      this.resetPage();
      this.loadData();
    })
  }
}
