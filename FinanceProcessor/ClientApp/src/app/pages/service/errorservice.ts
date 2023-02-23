import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorService {

    constructor(private toastr: ToastrService) { }

    public showErr500Msg() {
        this.toastr.show(
            '<span data-notify="icon" class="tim-icons icon-bell-55"></span>',
            'Network connection failed. Please check network connection',
            {
              timeOut: 4000,
              closeButton: true,
              enableHtml: true,
              toastClass: "alert alert-danger alert-with-icon",
              positionClass: "toast-top-right"
            }
          );
    }
}