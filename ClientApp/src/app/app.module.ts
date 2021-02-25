import { BrowserModule } from "@angular/platform-browser";
import { ErrorHandler, NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { VehicleFormComponent } from "./vehicle-form/vehicle-form.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";
import { GlobalErrorHandler } from "./app.error-handler";
import { VehicleListComponent } from "./vehicle-list/vehicle-list.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    VehicleFormComponent,
    VehicleListComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(
      [
        { path: "", redirectTo: "vehicles", pathMatch: "full" },
        { path: "vehicles/new", component: VehicleFormComponent },
        { path: "vehicles/:id", component: VehicleFormComponent },
        { path: "vehicles", component: VehicleListComponent },
        { path: "counter", component: CounterComponent },
        { path: "fetch-data", component: FetchDataComponent },
      ],
      { relativeLinkResolution: "legacy" }
    ),
  ],
  providers: [
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
