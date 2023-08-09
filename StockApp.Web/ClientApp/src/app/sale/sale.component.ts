import {Component, Inject, OnInit} from '@angular/core';
import {PaginationResponse} from "../models/pagination-response.model";
import {PaginationComponent} from "../components/pagination";
import {ISale} from "../models/sale/sale.model";
import {SaleService} from "../services/sale.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {SaleFormComponent} from "./sale-form/sale-form.component";

@Component({
  selector: 'app-sale',
  templateUrl: './sale.component.html'
})
export class SaleComponent extends PaginationComponent implements OnInit {
  sales: ISale[] = [];

  constructor(private saleService: SaleService,
              private modalService: NgbModal) {
    super();

    this.loadData();
  }

  ngOnInit() {

  }

  loadData(){
    this.saleService.getList(this.count, this.page).subscribe((res: PaginationResponse<ISale>) => {
      this.sales = res.data;
      this.total = res.total;
    });
  }

  create() {
    const modalRef = this.modalService.open(SaleFormComponent);
    modalRef.componentInstance.successCreate.subscribe(() => {
      this.resetPage();
      this.loadData();
    })
  }
}

