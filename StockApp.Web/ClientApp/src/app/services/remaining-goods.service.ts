import {Inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from "../../environments/environment";
import {BaseResponse} from "../models/base-response.model";
import {IRemainingGoods} from "../models/remaining-good/remaining-goods.model";

@Injectable({
  providedIn: 'root'
})
export class RemainingGoodsService {
  protected baseUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {

  }

  getResult (count: number, page: number) {
    return this.http.get<BaseResponse<IRemainingGoods>>(this.baseUrl + '/api/Good/GetRemainingGoods?count=' + count + '&page=' + page, {});
  }
}
