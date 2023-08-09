import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {GoodService} from "../../services/good.service";
import {IGood} from "../../models/good/good.model";
import {PaginationResponse} from "../../models/pagination-response.model";
import {ICreateAcceptanceGood} from "../../models/acceptance/create-acceptance-good.model";

@Component({
  selector: 'app-sale-good-form',
  templateUrl: './acceptance-good-form.component.html',
  styleUrls: ['./acceptance-good-form.component.css']
})
export class AcceptanceGoodFormComponent implements OnInit {
  @Output() successAdd: EventEmitter<ICreateAcceptanceGood> = new EventEmitter();

  form: FormGroup;

  goods: IGood[] = [];

  constructor(public activeModal: NgbActiveModal,
              private fb: FormBuilder,
              private goodService: GoodService) {

  }

  ngOnInit(): void {
    this.initForm();
    this.goodService.getList(0, 0).subscribe((res: PaginationResponse<IGood>) => {
      this.goods = res.data;
    });
  }

  initForm() {
    this.form = this.fb.group({
      good: ['', Validators.compose([Validators.required])],
      count: ['', Validators.compose([Validators.required, Validators.pattern('^[0-9]+(\\[0-9]{1,2})?$')])]
    });
  }

  get f() { return this.form.controls; }

  add(){
    const form = this.form.getRawValue();
    let acceptanceGood: ICreateAcceptanceGood = {
      goodId: form.good.id,
      name: form.good.name,
      count: form.count
    };

    this.successAdd.emit(acceptanceGood);
    this.activeModal.close();
  }
}
