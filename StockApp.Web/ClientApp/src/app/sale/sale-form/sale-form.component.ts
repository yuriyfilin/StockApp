import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NgbActiveModal, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {SaleGoodFormComponent} from "../sale-good-form/sale-good-form.component";
import {SaleService} from "../../services/sale.service";
import {ICreateSaleGood} from "../../models/sale/create-sale-good.model";
import {ICreateSale} from "../../models/sale/create-sale.model";

@Component({
  selector: 'app-sale-form',
  templateUrl: './sale-form.component.html',
  styleUrls: ['./sale-form.component.css']
})
export class SaleFormComponent implements OnInit {
  @Output() successCreate: EventEmitter<any> = new EventEmitter();

  saleGoods: ICreateSaleGood[] = [];
  constructor(public activeModal: NgbActiveModal,
              private modalService: NgbModal,
              private saleService: SaleService) { }

  ngOnInit(): void {
  }

  addGood() {
    const modalRef = this.modalService.open(SaleGoodFormComponent);
    modalRef.componentInstance.successAdd.subscribe((good:ICreateSaleGood) => {
      this.saleGoods.push(good);
    })
  }

  create() {
    let saleGood: ICreateSale = {
      saleGoods: this.saleGoods
    }

    this.saleService.create(saleGood).subscribe(() => {
      this.successCreate.emit();
      this.activeModal.close();
    });
  }
}
