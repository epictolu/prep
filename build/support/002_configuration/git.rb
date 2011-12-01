configs ={
  :git => {
    :user => "20111205_edmonton",
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'prep' 
  }
}
configatron.configure_from_hash(configs)
