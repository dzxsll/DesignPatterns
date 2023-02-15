# DesignPatterns
C#特性下的设计模式

创建模式的总结：
	Singleton单件模式解决的是实体对象个数的问题。
	除了Singleton之外，其他创建型模式解决的都是new所带来的耦合关系。
	基本思路是通过抽象和实现的分离,将"变化"下移到实现之中,修改就只在实现中变动，从而减少变动的范围，降低了耦合。
	如果遇到“易变类”，起初的设计通常从Factory Method开始，当遇到更多的复杂变化时，再考虑重构为其他三种工厂模式（Abstract Factory，Builder，Prototype）。