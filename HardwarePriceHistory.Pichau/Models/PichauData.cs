using Newtonsoft.Json;

namespace HardwarePriceHistory.Pichau.Models;


    public class Aggregation
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("attribute_code")]
        public string AttributeCode { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Breadcrumb
    {
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("category_level")]
        public int CategoryLevel { get; set; }

        [JsonProperty("category_url_key")]
        public string CategoryUrlKey { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("product_count")]
        public int ProductCount { get; set; }

        [JsonProperty("url_key")]
        public string UrlKey { get; set; }

        [JsonProperty("search_filters_order")]
        public string SearchFiltersOrder { get; set; }

        [JsonProperty("breadcrumbs")]
        public List<Breadcrumb> Breadcrumbs { get; set; }

        [JsonProperty("meta_title")]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Category2
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Data
    {
        [JsonProperty("category")]
        public Category? Category { get; set; }

        [JsonProperty("products")]
        public Products? Products { get; set; }

        [JsonProperty("banners")]
        public List<object>? Banners { get; set; }
    }

    public class Description
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class FinalPrice
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("url_listing")]
        public string UrlListing { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("url_key")]
        public string UrlKey { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("special_price")]
        public double? SpecialPrice { get; set; }

        [JsonProperty("socket")]
        public string Socket { get; set; }

        [JsonProperty("hide_from_search")]
        public int HideFromSearch { get; set; }

        [JsonProperty("is_openbox")]
        public int IsOpenbox { get; set; }

        [JsonProperty("openbox_state")]
        public object OpenboxState { get; set; }

        [JsonProperty("openbox_condition")]
        public object OpenboxCondition { get; set; }

        [JsonProperty("tipo_de_memoria")]
        public int? TipoDeMemoria { get; set; }

        [JsonProperty("caracteristicas")]
        public string Caracteristicas { get; set; }

        [JsonProperty("slots_memoria")]
        public string SlotsMemoria { get; set; }

        [JsonProperty("marcas")]
        public int Marcas { get; set; }

        [JsonProperty("marcas_info")]
        public MarcasInfo MarcasInfo { get; set; }

        [JsonProperty("formato_placa")]
        public string FormatoPlaca { get; set; }

        [JsonProperty("plataforma")]
        public object Plataforma { get; set; }

        [JsonProperty("portas_sata")]
        public string PortasSata { get; set; }

        [JsonProperty("slot_cooler_120")]
        public object SlotCooler120 { get; set; }

        [JsonProperty("slot_cooler_80")]
        public object SlotCooler80 { get; set; }

        [JsonProperty("slot_cooler_140")]
        public object SlotCooler140 { get; set; }

        [JsonProperty("slot_cooler_200")]
        public object SlotCooler200 { get; set; }

        [JsonProperty("coolerbox_included")]
        public object CoolerboxIncluded { get; set; }

        [JsonProperty("potencia")]
        public object Potencia { get; set; }

        [JsonProperty("quantidade_pacote")]
        public object QuantidadePacote { get; set; }

        [JsonProperty("alerta_monteseupc")]
        public object AlertaMonteseupc { get; set; }

        [JsonProperty("vgaintegrado")]
        public object Vgaintegrado { get; set; }

        [JsonProperty("product_set_name")]
        public string ProductSetName { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("price_range")]
        public PriceRange PriceRange { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("garantia")]
        public string Garantia { get; set; }

        [JsonProperty("informacoes_adicionais")]
        public string InformacoesAdicionais { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("media_gallery")]
        public List<MediaGallery> MediaGallery { get; set; }

        [JsonProperty("short_description")]
        public ShortDescription ShortDescription { get; set; }

        [JsonProperty("amasty_label")]
        public object AmastyLabel { get; set; }

        [JsonProperty("reviews")]
        public Reviews Reviews { get; set; }

        [JsonProperty("dailydeal_info")]
        public object DailydealInfo { get; set; }

        [JsonProperty("mysales_promotion")]
        public MysalesPromotion MysalesPromotion { get; set; }

        [JsonProperty("only_x_left_in_stock")]
        public object OnlyXLeftInStock { get; set; }

        [JsonProperty("stock_status")]
        public string StockStatus { get; set; }

        [JsonProperty("codigo_barra")]
        public string CodigoBarra { get; set; }

        [JsonProperty("codigo_ncm")]
        public string CodigoNcm { get; set; }

        [JsonProperty("meta_title")]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_keyword")]
        public string MetaKeyword { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class MarcasInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class MaximumPrice
    {
        [JsonProperty("final_price")]
        public FinalPrice FinalPrice { get; set; }

        [JsonProperty("regular_price")]
        public RegularPrice RegularPrice { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class MediaGallery
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("label")]
        public object Label { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class MinimumPrice
    {
        [JsonProperty("final_price")]
        public FinalPrice FinalPrice { get; set; }

        [JsonProperty("regular_price")]
        public RegularPrice RegularPrice { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class MysalesPromotion
    {
        [JsonProperty("expire_at")]
        public string ExpireAt { get; set; }

        [JsonProperty("price_discount")]
        public double PriceDiscount { get; set; }

        [JsonProperty("price_promotional")]
        public double PricePromotional { get; set; }

        [JsonProperty("promotion_name")]
        public string PromotionName { get; set; }

        [JsonProperty("promotion_url")]
        public string PromotionUrl { get; set; }

        [JsonProperty("qty_available")]
        public int QtyAvailable { get; set; }

        [JsonProperty("qty_sold")]
        public int QtySold { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Option
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class PageInfo
    {
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class PriceRange
    {
        [JsonProperty("minimum_price")]
        public MinimumPrice MinimumPrice { get; set; }

        [JsonProperty("maximum_price")]
        public MaximumPrice MaximumPrice { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Products
    {
        [JsonProperty("aggregations")]
        public List<Aggregation> Aggregations { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class RegularPrice
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class Reviews
    {
        [JsonProperty("rating")]
        public int? Rating { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class PichauProduct
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class ShortDescription
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

