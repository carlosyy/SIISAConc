// JavaScript Document
//Js para detectar si el "Block Mayus se encuentra activo"
//Texto que mostraremos de alerta 
var txtWarning = 'Ojo! tienes las mayusculas activas';
	
var capslock = {
  init: function() {
    if (!document.getElementsByTagName) {
      return;
    }
    var inps = document.getElementsByTagName("input");
    for (var i=0, l=inps.length; i<l; i++) {
      if (inps[i].type == "password") {
        capslock.addEvent(inps[i], "keypress", capslock.keypress);
      }
    }
  },
  addEvent: function(obj,evt,fn) {
    if (document.addEventListener) {
      capslock.addEvent = function (obj,evt,fn) {
        obj.addEventListener(evt,fn,false);
      };
      capslock.addEvent(obj,evt,fn);
    } else if (document.attachEvent) {
      capslock.addEvent = function (obj,evt,fn) {
        obj.attachEvent('on'+evt,fn);
      };
      capslock.addEvent(obj,evt,fn);
    } else { }
  },
  keypress: function(e) {
    var ev = e ? e : window.event;
    if (!ev) {
      return;
    }
    var targ = ev.target ? ev.target : ev.srcElement;
    var which = -1;
    if (ev.which) {
      which = ev.which;
    } else if (ev.keyCode) {
      which = ev.keyCode;
    }
    var shift_status = false;
    if (ev.shiftKey) {
      shift_status = ev.shiftKey;
    } else if (ev.modifiers) {
      shift_status = !!(ev.modifiers & 4);
    }
    if (((which >= 65 && which <=  90) && !shift_status) ||
        ((which >= 97 && which <= 122) && shift_status)) {
      capslock.show_warning(targ, this.parentNode);
    } else {
      capslock.hide_warning(targ, this.parentNode);
    }
  },

  show_warning: function(targ, elem) {
    if (!targ.warning) {
      targ.warning = document.createTextNode(txtWarning);
      elem.appendChild(targ.warning);
    }
  },
  hide_warning: function(targ, elem) {
    if (targ.warning) {
      elem.removeChild(targ.warning);
      targ.warning = null;
    }
  }
};