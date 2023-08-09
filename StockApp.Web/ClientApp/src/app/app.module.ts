import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { GoodComponent } from './good/good.component';
import { AcceptanceComponent } from './acceptance/acceptance.component';
import { SaleComponent } from './sale/sale.component';
import { NgbPaginationModule, NgbTypeaheadModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {GoodFormComponent} from "./good/good-form/good-form.component";
import {RemainingGoodsComponent} from "./remaining-goods/remaining-goods.component";
import {AcceptanceFormComponent} from "./acceptance/acceptance-form/acceptance-form.component";
import {AcceptanceGoodFormComponent} from "./acceptance/acceptance-good-form/acceptance-good-form.component";
import {SaleFormComponent} from "./sale/sale-form/sale-form.component";
import {SaleGoodFormComponent} from "./sale/sale-good-form/sale-good-form.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    GoodComponent,
    AcceptanceComponent,
    SaleComponent,
    GoodFormComponent,
    RemainingGoodsComponent,
    AcceptanceFormComponent,
    AcceptanceGoodFormComponent,
    SaleFormComponent,
    SaleGoodFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    NgbPaginationModule,
    NgbTypeaheadModule,
    RouterModule.forRoot([
      {path: '', component: GoodComponent, pathMatch: 'full'},
      {path: 'acceptance', component: AcceptanceComponent},
      {path: 'sale', component: SaleComponent},
      {path: 'remaining-goods', component: RemainingGoodsComponent},
    ]),
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
