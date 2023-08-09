import {Component, OnInit} from '@angular/core';
import {PaginationResponse} from "../models/pagination-response.model";
import {IAcceptance} from "../models/acceptance/acceptance.model";
import {AcceptanceService} from "../services/acceptance.service";
import {PaginationComponent} from "../components/pagination";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {AcceptanceFormComponent} from "./acceptance-form/acceptance-form.component";

@Component({
  selector: 'app-acceptance-component',
  templateUrl: './acceptance.component.html'
})
export class AcceptanceComponent extends PaginationComponent implements OnInit {
  acceptances: IAcceptance[] = [];

  constructor(private acceptanceService: AcceptanceService,
              private modalService: NgbModal
  ) {
    super();

    this.loadData();
  }

  ngOnInit() {

  }

  loadData(){
    this.acceptanceService.getList(this.count, this.page).subscribe((res: PaginationResponse<IAcceptance>) => {
      this.acceptances = res.data;
      this.total = res.total;
    });
  }

  create() {
    const modalRef = this.modalService.open(AcceptanceFormComponent);
    modalRef.componentInstance.successCreate.subscribe(() => {
      this.resetPage();
      this.loadData();
    })
  }
}
