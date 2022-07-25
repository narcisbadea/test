/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { ItemRequestDto } from '../models/item-request-dto';
import { ItemResponseDto } from '../models/item-response-dto';
import { ItemResponseForAdminDto } from '../models/item-response-for-admin-dto';

@Injectable({
  providedIn: 'root',
})
export class AdminItemsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiAdminItemsUnlisteditemsNrGet
   */
  static readonly ApiAdminItemsUnlisteditemsNrGetPath = '/api/AdminItems/unlisteditems/{nr}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsUnlisteditemsNrGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsUnlisteditemsNrGet$Plain$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsUnlisteditemsNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsUnlisteditemsNrGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsUnlisteditemsNrGet$Plain(params: {
    nr: number;
  }): Observable<Array<ItemResponseDto>> {

    return this.apiAdminItemsUnlisteditemsNrGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseDto>>) => r.body as Array<ItemResponseDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsUnlisteditemsNrGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsUnlisteditemsNrGet$Json$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsUnlisteditemsNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsUnlisteditemsNrGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsUnlisteditemsNrGet$Json(params: {
    nr: number;
  }): Observable<Array<ItemResponseDto>> {

    return this.apiAdminItemsUnlisteditemsNrGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseDto>>) => r.body as Array<ItemResponseDto>)
    );
  }

  /**
   * Path part for operation apiAdminItemsListeditemsNrGet
   */
  static readonly ApiAdminItemsListeditemsNrGetPath = '/api/AdminItems/listeditems/{nr}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsListeditemsNrGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsListeditemsNrGet$Plain$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseForAdminDto>>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsListeditemsNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseForAdminDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsListeditemsNrGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsListeditemsNrGet$Plain(params: {
    nr: number;
  }): Observable<Array<ItemResponseForAdminDto>> {

    return this.apiAdminItemsListeditemsNrGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseForAdminDto>>) => r.body as Array<ItemResponseForAdminDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsListeditemsNrGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsListeditemsNrGet$Json$Response(params: {
    nr: number;
  }): Observable<StrictHttpResponse<Array<ItemResponseForAdminDto>>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsListeditemsNrGetPath, 'get');
    if (params) {
      rb.path('nr', params.nr, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<ItemResponseForAdminDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsListeditemsNrGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsListeditemsNrGet$Json(params: {
    nr: number;
  }): Observable<Array<ItemResponseForAdminDto>> {

    return this.apiAdminItemsListeditemsNrGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<ItemResponseForAdminDto>>) => r.body as Array<ItemResponseForAdminDto>)
    );
  }

  /**
   * Path part for operation apiAdminItemsIdGet
   */
  static readonly ApiAdminItemsIdGetPath = '/api/AdminItems/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Blob>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'blob',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Blob>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdGet$Plain(params: {
    id: number;
  }): Observable<Blob> {

    return this.apiAdminItemsIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<Blob>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'blob',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Blob>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdGet$Json(params: {
    id: number;
  }): Observable<Blob> {

    return this.apiAdminItemsIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Blob>) => r.body as Blob)
    );
  }

  /**
   * Path part for operation apiAdminItemsIdPut
   */
  static readonly ApiAdminItemsIdPutPath = '/api/AdminItems/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsIdPut()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdPut$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsIdPut$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdPut(params: {
    id: number;
  }): Observable<void> {

    return this.apiAdminItemsIdPut$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiAdminItemsIdDelete
   */
  static readonly ApiAdminItemsIdDeletePath = '/api/AdminItems/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsIdDelete(params: {
    id: number;
  }): Observable<void> {

    return this.apiAdminItemsIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiAdminItemsNumbersOfItemsGet
   */
  static readonly ApiAdminItemsNumbersOfItemsGetPath = '/api/AdminItems/numbers-of-items';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsNumbersOfItemsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsNumbersOfItemsGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsNumbersOfItemsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsNumbersOfItemsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsNumbersOfItemsGet$Plain(params?: {
  }): Observable<number> {

    return this.apiAdminItemsNumbersOfItemsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsNumbersOfItemsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsNumbersOfItemsGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<number>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsNumbersOfItemsGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: parseFloat(String((r as HttpResponse<any>).body)) }) as StrictHttpResponse<number>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsNumbersOfItemsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsNumbersOfItemsGet$Json(params?: {
  }): Observable<number> {

    return this.apiAdminItemsNumbersOfItemsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<number>) => r.body as number)
    );
  }

  /**
   * Path part for operation apiAdminItemsPost
   */
  static readonly ApiAdminItemsPostPath = '/api/AdminItems';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAdminItemsPost$Plain$Response(params?: {
    body?: ItemRequestDto
  }): Observable<StrictHttpResponse<ItemResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ItemResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAdminItemsPost$Plain(params?: {
    body?: ItemRequestDto
  }): Observable<ItemResponseDto> {

    return this.apiAdminItemsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ItemResponseDto>) => r.body as ItemResponseDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAdminItemsPost$Json$Response(params?: {
    body?: ItemRequestDto
  }): Observable<StrictHttpResponse<ItemResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ItemResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiAdminItemsPost$Json(params?: {
    body?: ItemRequestDto
  }): Observable<ItemResponseDto> {

    return this.apiAdminItemsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ItemResponseDto>) => r.body as ItemResponseDto)
    );
  }

  /**
   * Path part for operation apiAdminItemsSoldbyadminIdDelete
   */
  static readonly ApiAdminItemsSoldbyadminIdDeletePath = '/api/AdminItems/soldbyadmin/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiAdminItemsSoldbyadminIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsSoldbyadminIdDelete$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, AdminItemsService.ApiAdminItemsSoldbyadminIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiAdminItemsSoldbyadminIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiAdminItemsSoldbyadminIdDelete(params: {
    id: number;
  }): Observable<void> {

    return this.apiAdminItemsSoldbyadminIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
