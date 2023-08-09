import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {GoodService} from "../../services/good.service";
import {IUnits} from "../../models/units/units.model";
import {UnitsService} from "../../services/units.service";
import {BaseResponse} from "../../models/base-response.model";

@Component({
  selector: 'app-good-form',
  templateUrl: './good-form.component.html',
  styleUrls: ['./good-form.component.css']
})
export class GoodFormComponent implements OnInit {
  @Output() successCreate: EventEmitter<any> = new EventEmitter();

  form: FormGroup;

  units: IUnits[] = [];
  constructor(public activeModal: NgbActiveModal,
              private fb: FormBuilder,
              private goodService: GoodService,
              private unitsService: UnitsService) {

  }

  ngOnInit(): void {
    this.initForm();
    this.unitsService.getList().subscribe((res: BaseResponse<IUnits[]>) => {
      this.units = res.data;
    });
  }

  initForm() {
    this.form = this.fb.group({
      name: ['', Validators.compose([Validators.required])],
      vendorCode: ['', Validators.compose([Validators.required])],
      purchasePrice: ['', Validators.compose([Validators.required, Validators.pattern('^[0-9]+(\\.[0-9]{1,2})?$')])],
      sellingPrice: ['', Validators.compose([Validators.required, Validators.pattern('^[0-9]+(\\.[0-9]{1,2})?$')])],
      units: ['', Validators.compose([Validators.required])]
    });
  }

  get f() { return this.form.controls; }

  create(){
    const form = this.form.getRawValue();

    this.goodService.create(form).subscribe(() => {
      this.successCreate.emit();
      this.activeModal.close();
    });
  }
}
