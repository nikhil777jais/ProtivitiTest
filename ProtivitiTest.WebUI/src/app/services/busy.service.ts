import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
    providedIn: 'root'
})
export class BusyService {

    busyRequestCount = 0;

    constructor(private spinnerService: NgxSpinnerService) { }

    busy() {
        this.busyRequestCount++;
        this.spinnerService.show(undefined, {
            type: 'ball-clip-rotate-multiple',
            bdColor: 'rgba(213, 213, 212, .9)',
            color: '#1c100b',
            size: 'medium',
            showSpinner: true,
            fullScreen: true
        })
    }

    idle() {
        this.busyRequestCount--;
        if (this.busyRequestCount <= 0) {
            this.busyRequestCount = 0;
            this.spinnerService.hide();
        }
    }
}
