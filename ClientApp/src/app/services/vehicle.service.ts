import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Vehicle } from "../models/vehicle";
import { SaveVehicle } from "../models/saveVehicle";

@Injectable({
  providedIn: "root",
})
export class VehicleService {
  constructor(private http: HttpClient) {}
  getMakes() {
    return this.http.get<any[]>("/api/makes");
  }
  getFeatures() {
    return this.http.get<any[]>("/api/features");
  }
  createVehicle(vehicle) {
    return this.http.post<any[]>("api/vehicles", vehicle);
  }
  getVehicle(id) {
    return this.http.get<Vehicle>("api/vehicles/" + id);
  }
  getVehicles() {
    return this.http.get<Vehicle[]>("api/vehicles");
  }
  updateVehicle(vehicle: SaveVehicle) {
    return this.http.put<Vehicle>("api/vehicles/" + vehicle.id, vehicle);
  }

  deleteVehicle(id) {
    return this.http.delete<Vehicle>("api/vehicles/" + id);
  }
}
