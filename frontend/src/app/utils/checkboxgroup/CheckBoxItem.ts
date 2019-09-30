export class CheckboxItem {
    id: string;
    description: string;
    checked: boolean;
    constructor(id: any, description: any, checked?: boolean) {
        this.id = id;
        this.description = description;
        this.checked = checked ? checked : false;
    }
}