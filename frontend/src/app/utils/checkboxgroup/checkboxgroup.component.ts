import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CheckboxItem } from './CheckBoxItem';

@Component({
  selector: 'app-checkboxgroup',
  templateUrl: './checkboxgroup.component.html',
  styleUrls: ['./checkboxgroup.component.css']
})
export class CheckboxgroupComponent implements OnInit {

  constructor() { }

  @Input() options = Array<any>();
  @Input() selectedValues = Array<any>();
  @Output() toggle = new EventEmitter<any[]>();

  ngOnInit() { }

  onToggle() {
    const checkedOptions = this.options.filter(x => x.checked);
    this.selectedValues = checkedOptions.map(x => x.id);
    this.toggle.emit(checkedOptions.map(x => x.id));
  }

  ngAfterViewChecked() {
    if (this.selectedValues) {
      this.selectedValues.forEach(value => {
        const element = this.options.find(x => x.id === value.id);
        if (element) {
          element.checked = true;
        }
      });
    }
  }
}
