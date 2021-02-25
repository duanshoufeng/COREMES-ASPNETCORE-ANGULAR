import { VehicleService } from "./../services/vehicle.service";
import { ToastrService } from "ngx-toastr";
import { Vehicle } from "./../models/vehicle";
import { SaveVehicle } from "../models/saveVehicle";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { forkJoin, Observable } from "rxjs";
import * as _ from "lodash-es";

@Component({
  selector: "app-vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"],
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: "",
      email: "",
      phone: "",
    },
  };
  features: any[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private vehicleService: VehicleService,
    private toastyService: ToastrService
  ) {
    route.params.subscribe((p) => {
      this.vehicle.id = +p["id"];
    });
  }

  ngOnInit(): void {
    if (this.vehicle.id) {
      forkJoin({
        makes: this.vehicleService.getMakes(),
        features: this.vehicleService.getFeatures(),
        vehicle: this.vehicleService.getVehicle(this.vehicle.id),
      }).subscribe((data) => {
        this.makes = data.makes;
        this.features = data.features;
        this.setVehicle(data.vehicle);
        this.populateModels();
      });
    } else {
      forkJoin({
        makes: this.vehicleService.getMakes(),
        features: this.vehicleService.getFeatures(),
      }).subscribe((data) => {
        this.makes = data.makes;
        this.features = data.features;
      });
    }
  }

  private setVehicle(v: Vehicle) {
    this.vehicle.id = v.id;
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.contact = v.contact;
    this.vehicle.features = _.map(v.features, "id");
  }

  onMakeChange() {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  private populateModels() {
    const selectedMake = this.makes.find(
      (make) => make.id == this.vehicle.makeId
    );
    this.models = selectedMake ? selectedMake.models : [];
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked) this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    if (this.vehicle.id)
      this.vehicleService.updateVehicle(this.vehicle).subscribe((x) => {
        this.toastyService.success(
          "The vehicle was successfully updated.",
          "Success",
          { timeOut: 3000 }
        );
      });
    else {
      this.vehicleService
        .createVehicle(this.vehicle)
        .subscribe((x) => console.log(x));
    }
  }

  delete() {
    if (confirm("Are you sure?"))
      this.vehicleService.deleteVehicle(this.vehicle.id).subscribe((x) => {
        this.router.navigate(["/"]);
      });
  }
}
