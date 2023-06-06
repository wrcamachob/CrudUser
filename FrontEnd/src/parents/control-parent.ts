import { CommondParent } from './commond-parent';
import { faSync, faBackspace, faCalendarAlt } from '@fortawesome/free-solid-svg-icons';

export abstract class ControlParent extends CommondParent {

    iconSync = faSync;
    iconBackspace = faBackspace;
    iconCalendar = faCalendarAlt;

    constructor() {
        super();
    }

}
