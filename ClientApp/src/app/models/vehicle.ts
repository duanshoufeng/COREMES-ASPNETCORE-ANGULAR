import { Contact } from "./contact";
import { KeyValue } from "./keyValue";

export interface Vehicle {
  id: number;
  model: KeyValue;
  make: KeyValue;
  isRegistered: boolean;
  features: KeyValue[];
  contact: Contact;
  lastUpdate: string;
}
