import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ISale} from "../models/sale/sale.model";
import {environment} from "../../environments/environment";
import {PaginationResponse} from "../models/pagination-response.model";
import {ICreateSale} from "../models/sale/create-sale.model";

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  protected baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {

  }


  getList (count: number, page: number) {
    return this.http.get<PaginationResponse<ISale>>(this.baseUrl + '/api/Sale/GetSales?count=' + count + '&page=' + page, {});
  }

  create(sale: ICreateSale){
    return this.http.post(this.baseUrl + '/api/Sale/Add', sale);
  }
}
