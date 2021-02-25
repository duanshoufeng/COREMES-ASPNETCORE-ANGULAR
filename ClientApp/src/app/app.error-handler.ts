import { ToastrService } from "ngx-toastr";
import { ErrorHandler, Injectable, Injector, NgZone } from "@angular/core";

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor(private injector: Injector, private ngZone: NgZone) {}

  handleError(error: Error) {
    const err = {
      message: error.message ? error.message : error.toString(),
      stack: error.stack ? error.stack : "",
    };

    // Log  the error
    console.log(err);

    // Optionally send it to your back-end API
    // Notify the user
    const notificationService = this.injector.get(ToastrService);

    this.ngZone.run(() => {
      notificationService.error("An unexpected error happened!", "Error", {
        timeOut: 3000,
      });
    });
  }
}
