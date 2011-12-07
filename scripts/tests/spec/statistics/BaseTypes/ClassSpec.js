

var a, b;

beforeEach(function () {
    a = Statistics.Class({

        className: null,

        _init: function () {
            this.className = 'classe a';
        },

        func: function () {
            return this.className;
        }

    });


    b = Statistics.Class(a, {

        _init: function () {

            a.prototype._init.apply(this, arguments);
        },

        func: function () {


            return 'classe b';
        },

        concatenateFunc: function () {
            return this.func() + ' ' + a.prototype.func.apply(this, []);
        }

    });
});




describe("Statistics.Class", function () {


    var binstance;


    beforeEach(function () {
        binstance = new b();
    });



    it("can override methods", function () {

        var str = binstance.func();

        expect(str).toBe('classe b');

    });


    it("can call base method", function () {

        var str = binstance.concatenateFunc();

        expect(str).toBe('classe b classe a');

    });

    it("can verify inheritance instance", function () {

        var isInstanceOf = binstance instanceof a;

        expect(isInstanceOf).toBeTruthy();
    });


    it("should fail", function () {

        var arr = new Array();
        var isInstanceOf = arr instanceof a;

        expect(isInstanceOf).toBeFalsy();
    });

});