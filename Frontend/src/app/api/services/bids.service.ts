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

import { BidRequestDto } from '../models/bid-request-dto';
import { BidResponseDto } from '../models/bid-response-dto';

@Injectable({
  providedIn: 'root',
})
export class BidsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiBidsGetAllGet
   */
  static readonly ApiBidsGetAllGetPath = '/api/Bids/get-all';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBidsGetAllGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetAllGet$Plain$Response(params?: {
  }): Observable<StrictHttpResponse<Array<BidResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, BidsService.ApiBidsGetAllGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<BidResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiBidsGetAllGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetAllGet$Plain(params?: {
  }): Observable<Array<BidResponseDto>> {

    return this.apiBidsGetAllGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<BidResponseDto>>) => r.body as Array<BidResponseDto>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBidsGetAllGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetAllGet$Json$Response(params?: {
  }): Observable<StrictHttpResponse<Array<BidResponseDto>>> {

    const rb = new RequestBuilder(this.rootUrl, BidsService.ApiBidsGetAllGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<BidResponseDto>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiBidsGetAllGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetAllGet$Json(params?: {
  }): Observable<Array<BidResponseDto>> {

    return this.apiBidsGetAllGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<BidResponseDto>>) => r.body as Array<BidResponseDto>)
    );
  }

  /**
   * Path part for operation apiBidsGetByIdIdGet
   */
  static readonly ApiBidsGetByIdIdGetPath = '/api/Bids/get-by-id/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBidsGetByIdIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetByIdIdGet$Plain$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<BidResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, BidsService.ApiBidsGetByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<BidResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiBidsGetByIdIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetByIdIdGet$Plain(params: {
    id: number;
  }): Observable<BidResponseDto> {

    return this.apiBidsGetByIdIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<BidResponseDto>) => r.body as BidResponseDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBidsGetByIdIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetByIdIdGet$Json$Response(params: {
    id: number;
  }): Observable<StrictHttpResponse<BidResponseDto>> {

    const rb = new RequestBuilder(this.rootUrl, BidsService.ApiBidsGetByIdIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<BidResponseDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiBidsGetByIdIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBidsGetByIdIdGet$Json(params: {
    id: number;
  }): Observable<BidResponseDto> {

    return this.apiBidsGetByIdIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<BidResponseDto>) => r.body as BidResponseDto)
    );
  }

  /**
   * Path part for operation apiBidsPostPost
   */
  static readonly ApiBidsPostPostPath = '/api/Bids/post';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBidsPostPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBidsPostPost$Plain$Response(params?: {
    body?: BidRequestDto
  }): Observable<StrictHttpResponse<BidRequestDto>> {

    const rb = new RequestBuilder(this.rootUrl, BidsService.ApiBidsPostPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<BidRequestDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiBidsPostPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBidsPostPost$Plain(params?: {
    body?: BidRequestDto
  }): Observable<BidRequestDto> {

    return this.apiBidsPostPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<BidRequestDto>) => r.body as BidRequestDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBidsPostPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBidsPostPost$Json$Response(params?: {
    body?: BidRequestDto
  }): Observable<StrictHttpResponse<BidRequestDto>> {

    const rb = new RequestBuilder(this.rootUrl, BidsService.ApiBidsPostPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<BidRequestDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiBidsPostPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBidsPostPost$Json(params?: {
    body?: BidRequestDto
  }): Observable<BidRequestDto> {

    return this.apiBidsPostPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<BidRequestDto>) => r.body as BidRequestDto)
    );
  }

}
