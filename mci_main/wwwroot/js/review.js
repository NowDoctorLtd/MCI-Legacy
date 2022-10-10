console.log("Hello from review!");

var adjModel = Backbone.Model.extend({
    defaults: { name: "", rank: 0, mciIdx: 0 } 
});


var adjCollectionCtr = Backbone.Collection.extend({
    model: adjModel,
    url: "/api/adjectives/0",
    id: "mciIdx",
    parse: function (data) {
        return data.adjectives;
    }
});

var adjs = new adjCollectionCtr();

var adjViewCtr = Backbone.View.extend({
    el: "#adjList",
    tagName: 'li',
    className: 'adj',

    initialize: function () {
        this.render();
    },

});

var adjList = new adjViewCtr({ 
    model: adjModel,
    collection: adjs,
    initialize: function () {
        console.log(this.collection); 
    }
});

adjs.fetch().then(function () { 
    console.log(JSON.stringify(adjs));
    console.log("itm 1" + JSON.stringify(adjs.findWhere({name:"Empathetic"})));
    adjList.render();
});

var renderListItem = function (itm) {
    var html = '<li>' + itm.get('name') + '</li>';
    this.$el.html(html);
    return this;
};

console.log("done");
