import { Injectable } from '@angular/core';
import notify from 'devextreme/ui/notify';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  showErrorMessage(msg: string): void {
    this.showMessage(msg, 'error');
  }

  showInfoMessage(msg: string): void {
    this.showMessage(msg, 'info');
  }

  showSuccessMessage(msg: string): void {
    this.showMessage(msg, 'success');
  }

  showWarningMessage(msg: string): void {
    this.showMessage(msg, 'warning');
  }

  private showMessage(msg: string, type: string): void {
    notify({
      message: msg,
      position: {
        my: 'center top',
        at: 'center top',
      },
    }, type, 4000);
  }
}
