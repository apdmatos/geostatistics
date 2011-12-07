describe("Events", function () {

    function someType() {};
    var obj = new someType();
    var callback;

    beforeEach(function () {
        count = 0;
        callback = jasmine.createSpy();
        $(document).unbind("fire");
        $(obj).unbind("fire");
    });

    it('should bind a global event', function(){
        Statistics.Events.bind("fire", callback);
        $(document).triggerHandler("fire");   
        expect(callback).toHaveBeenCalled();        
    });
    
    it('should bind a instance event', function () {
        Statistics.Events.bind("fire", callback, obj);
        $(obj).triggerHandler("fire");
        expect(callback).toHaveBeenCalled();
    });

    it('should unbind a global event', function () {
        Statistics.Events.bind("fire", callback);
        Statistics.Events.unbind("fire", callback);
        $(document).triggerHandler("fire");
        expect(callback).not.toHaveBeenCalled();
    });

    it('should unbind a instance event', function () {
        Statistics.Events.bind("fire", callback, obj);
        Statistics.Events.unbind("fire", callback, obj);
        $(obj).triggerHandler("fire");
        expect(callback).not.toHaveBeenCalled();
    });

	it('should call the global event even when we trigger an instance event', function(){
        Statistics.Events.bind("fire", callback);
        $(document).triggerHandler("fire", [], new Object());
        expect(callback).toHaveBeenCalled();
    });      
    
    it('should trigger a global event', function(){
        Statistics.Events.bind("fire", callback);
        Statistics.Events.trigger("fire");
        expect(callback).toHaveBeenCalled();
    });

    it('should trigger a instance event', function(){
        Statistics.Events.bind("fire", callback, obj);
        Statistics.Events.trigger("fire", [], obj);
        expect(callback).toHaveBeenCalled();
    });
	
	it('should trigger the global event even when the instance event is triggered', function(){
        Statistics.Events.bind("fire", callback);
        Statistics.Events.trigger("fire", [], obj);
        expect(callback).toHaveBeenCalled();
    });
        
});