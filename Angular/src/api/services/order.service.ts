/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { OrderViewModel } from '../models/order-view-model';
@Injectable({
  providedIn: 'root',
})
class OrderService extends __BaseService {
  static readonly GetPath = '/api/Order/{id}';
  static readonly UpdatePath = '/api/Order/{id}';
  static readonly DeletePath = '/api/Order/{id}';
  static readonly AddPath = '/api/Order';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @param id undefined
   * @return Success
   */
  GetResponse(id: number): __Observable<__StrictHttpResponse<OrderViewModel>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Order/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<OrderViewModel>;
      })
    );
  }
  /**
   * @param id undefined
   * @return Success
   */
  Get(id: number): __Observable<OrderViewModel> {
    return this.GetResponse(id).pipe(
      __map(_r => _r.body as OrderViewModel)
    );
  }

  /**
   * @param params The `OrderService.UpdateParams` containing the following parameters:
   *
   * - `id`:
   *
   * - `order`:
   */
  UpdateResponse(params: OrderService.UpdateParams): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    __body = params.order;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Order/${params.id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param params The `OrderService.UpdateParams` containing the following parameters:
   *
   * - `id`:
   *
   * - `order`:
   */
  Update(params: OrderService.UpdateParams): __Observable<null> {
    return this.UpdateResponse(params).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param id undefined
   */
  DeleteResponse(id: number): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Order/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param id undefined
   */
  Delete(id: number): __Observable<null> {
    return this.DeleteResponse(id).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param order undefined
   */
  AddResponse(order?: OrderViewModel): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = order;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Order`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param order undefined
   */
  Add(order?: OrderViewModel): __Observable<null> {
    return this.AddResponse(order).pipe(
      __map(_r => _r.body as null)
    );
  }
}

module OrderService {

  /**
   * Parameters for Update
   */
  export interface UpdateParams {
    id: string;
    order?: OrderViewModel;
  }
}

export { OrderService }
