import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NgbActiveModal, NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {AcceptanceGoodFormComponent} from "../acceptance-good-form/acceptance-good-form.component";
import {ICreateAcceptanceGood} from "../../models/acceptance/create-acceptance-good.model";
import {ICreateAcceptance} from "../../models/acceptance/create-acceptance.model";
import {AcceptanceService} from "../../services/acceptance.service";

@Component({
  selector: 'app-sale-form',
  templateUrl: './acceptance-form.component.html',
  styleUrls: ['./acceptance-form.component.css']
})
export class AcceptanceFormComponent implements OnInit {
  @Output() successCreate: EventEmitter<any> = new EventEmitter();

  acceptanceGoods: ICreateAcceptanceGood[] = [];
  constructor(public activeModal: NgbActiveModal,
              private modalService: NgbModal,
              private acceptanceService: AcceptanceService) { }

  ngOnInit(): void {
  }

  addGood() {
    const modalRef = this.modalService.open(AcceptanceGoodFormComponent);
    modalRef.componentInstance.successAdd.subscribe((good:ICreateAcceptanceGood) => {
      this.acceptanceGoods.push(good);
    })
  }

  create() {
    let acceptanceGood: ICreateAcceptance = {
      acceptanceGoods: this.acceptanceGoods
    }

    this.acceptanceService.create(acceptanceGood).subscribe(() => {
      this.successCreate.emit();
      this.activeModal.close();
    });
  }
}
