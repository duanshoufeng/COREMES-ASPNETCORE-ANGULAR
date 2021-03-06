import { Component, OnInit } from "@angular/core";
import { KeyValue } from "../models/keyValue";
import { Vehicle } from "../models/vehicle";
import { VehicleService } from "../services/vehicle.service";

@Component({
  selector: "app-vehicle-list",
  templateUrl: "./vehicle-list.component.html",
  styleUrls: ["./vehicle-list.component.css"],
})
export class VehicleListComponent implements OnInit {
  vehicles: Vehicle[];
  allVehicles: Vehicle[];
  makes: KeyValue[];
  filter: any = {};

  constructor(private vehicleService: VehicleService) {}

  ngOnInit(): void {
    this.vehicleService.getMakes().subscribe((makes) => (this.makes = makes));
    this.vehicleService
      .getVehicles()
      .subscribe((vehicles) => (this.vehicles = this.allVehicles = vehicles));
  }

  onFilterChange() {
    var vehicles = this.allVehicles;

    if (this.filter.makeId)
      vehicles = vehicles.filter((v) => v.make.id == this.filter.makeId);

    this.vehicles = vehicles;

    console.log(this.filter);
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }
}
