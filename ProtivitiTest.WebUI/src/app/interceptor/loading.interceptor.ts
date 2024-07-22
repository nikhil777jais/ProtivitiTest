import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { Observable, delay, finalize } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BusyService } from '../services/busy.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

    constructor(private busyService: BusyService) { }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        this.busyService.busy();
        return next.handle(request).pipe(
            // (environment.production ? delay(2000) : delay(2000)),
            finalize(() => {
                this.busyService.idle();
            })
        )
    }
}
