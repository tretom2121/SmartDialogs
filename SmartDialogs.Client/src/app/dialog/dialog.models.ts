export interface DialogState {
  currentState: string;
  parameters: { [key: string]: any };
}

export interface Parameter {
  name: string;
  value: any;
  dataType: string;
}
