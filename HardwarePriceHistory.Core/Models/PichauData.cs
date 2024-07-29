using Newtonsoft.Json;

namespace HardwarePriceHistory.Core.Models;

public class Aggregation
{
    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    public int? Count { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public string Label { get; set; }

    [JsonProperty("attribute_code", NullValueHandling = NullValueHandling.Ignore)]
    public string AttributeCode { get; set; }

    [JsonProperty("options", NullValueHandling = NullValueHandling.Ignore)]
    public List<Option> Options { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class AmastyLabel
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("product_labels", NullValueHandling = NullValueHandling.Ignore)]
    public List<ProductLabel> ProductLabels { get; set; }

    [JsonProperty("category_labels", NullValueHandling = NullValueHandling.Ignore)]
    public List<CategoryLabel> CategoryLabels { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Breadcrumb
{
    [JsonProperty("category_id", NullValueHandling = NullValueHandling.Ignore)]
    public int? CategoryId { get; set; }

    [JsonProperty("category_name", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryName { get; set; }

    [JsonProperty("category_level", NullValueHandling = NullValueHandling.Ignore)]
    public int? CategoryLevel { get; set; }

    [JsonProperty("category_url_key", NullValueHandling = NullValueHandling.Ignore)]
    public string CategoryUrlKey { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Category
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public int? Id { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("product_count", NullValueHandling = NullValueHandling.Ignore)]
    public int? ProductCount { get; set; }

    [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
    public string UrlKey { get; set; }

    [JsonProperty("search_filters_order", NullValueHandling = NullValueHandling.Ignore)]
    public string SearchFiltersOrder { get; set; }

    [JsonProperty("breadcrumbs", NullValueHandling = NullValueHandling.Ignore)]
    public List<Breadcrumb> Breadcrumbs { get; set; }

    [JsonProperty("pichau_faq", NullValueHandling = NullValueHandling.Ignore)]
    public List<PichauFaq> PichauFaq { get; set; }

    [JsonProperty("meta_title", NullValueHandling = NullValueHandling.Ignore)]
    public string MetaTitle { get; set; }

    [JsonProperty("meta_keywords", NullValueHandling = NullValueHandling.Ignore)]
    public string MetaKeywords { get; set; }

    [JsonProperty("meta_description", NullValueHandling = NullValueHandling.Ignore)]
    public string MetaDescription { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Category2
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("url_path", NullValueHandling = NullValueHandling.Ignore)]
    public string UrlPath { get; set; }

    [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
    public string Path { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class CategoryLabel
{
    [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
    public string Image { get; set; }

    [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
    public string Position { get; set; }

    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public int? Size { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public string Label { get; set; }

    [JsonProperty("label_color", NullValueHandling = NullValueHandling.Ignore)]
    public string LabelColor { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Data
{
    [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
    public Category Category { get; set; }

    [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
    public Products Products { get; set; }

    [JsonProperty("banners", NullValueHandling = NullValueHandling.Ignore)]
    public List<object> Banners { get; set; }
}

public class Description
{
    [JsonProperty("html", NullValueHandling = NullValueHandling.Ignore)]
    public string Html { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Image
{
    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string Url { get; set; }

    [JsonProperty("url_listing", NullValueHandling = NullValueHandling.Ignore)]
    public string UrlListing { get; set; }

    [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
    public string Path { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public string Label { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Item
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public int? Id { get; set; }

    [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
    public string Sku { get; set; }

    [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
    public string UrlKey { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("socket", NullValueHandling = NullValueHandling.Ignore)]
    public string Socket { get; set; }

    [JsonProperty("hide_from_search", NullValueHandling = NullValueHandling.Ignore)]
    public int? HideFromSearch { get; set; }

    [JsonProperty("is_openbox", NullValueHandling = NullValueHandling.Ignore)]
    public int? IsOpenbox { get; set; }

    [JsonProperty("openbox_state", NullValueHandling = NullValueHandling.Ignore)]
    public object OpenboxState { get; set; }

    [JsonProperty("openbox_condition", NullValueHandling = NullValueHandling.Ignore)]
    public object OpenboxCondition { get; set; }

    [JsonProperty("tipo_de_memoria", NullValueHandling = NullValueHandling.Ignore)]
    public int? TipoDeMemoria { get; set; }

    [JsonProperty("caracteristicas", NullValueHandling = NullValueHandling.Ignore)]
    public string Caracteristicas { get; set; }

    [JsonProperty("slots_memoria", NullValueHandling = NullValueHandling.Ignore)]
    public string SlotsMemoria { get; set; }

    [JsonProperty("marcas", NullValueHandling = NullValueHandling.Ignore)]
    public int? Marcas { get; set; }

    [JsonProperty("marcas_info", NullValueHandling = NullValueHandling.Ignore)]
    public MarcasInfo MarcasInfo { get; set; }

    [JsonProperty("product_page_layout", NullValueHandling = NullValueHandling.Ignore)]
    public object ProductPageLayout { get; set; }

    [JsonProperty("formato_placa", NullValueHandling = NullValueHandling.Ignore)]
    public string FormatoPlaca { get; set; }

    [JsonProperty("plataforma", NullValueHandling = NullValueHandling.Ignore)]
    public object Plataforma { get; set; }

    [JsonProperty("portas_sata", NullValueHandling = NullValueHandling.Ignore)]
    public string PortasSata { get; set; }

    [JsonProperty("slot_cooler_120", NullValueHandling = NullValueHandling.Ignore)]
    public object SlotCooler120 { get; set; }

    [JsonProperty("slot_cooler_80", NullValueHandling = NullValueHandling.Ignore)]
    public object SlotCooler80 { get; set; }

    [JsonProperty("slot_cooler_140", NullValueHandling = NullValueHandling.Ignore)]
    public object SlotCooler140 { get; set; }

    [JsonProperty("slot_cooler_200", NullValueHandling = NullValueHandling.Ignore)]
    public object SlotCooler200 { get; set; }

    [JsonProperty("coolerbox_included", NullValueHandling = NullValueHandling.Ignore)]
    public object CoolerboxIncluded { get; set; }

    [JsonProperty("potencia", NullValueHandling = NullValueHandling.Ignore)]
    public object Potencia { get; set; }

    [JsonProperty("quantidade_pacote", NullValueHandling = NullValueHandling.Ignore)]
    public object QuantidadePacote { get; set; }

    [JsonProperty("alerta_monteseupc", NullValueHandling = NullValueHandling.Ignore)]
    public object AlertaMonteseupc { get; set; }

    [JsonProperty("vgaintegrado", NullValueHandling = NullValueHandling.Ignore)]
    public object Vgaintegrado { get; set; }

    [JsonProperty("product_set_name", NullValueHandling = NullValueHandling.Ignore)]
    public string ProductSetName { get; set; }

    [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
    public List<Category> Categories { get; set; }

    [JsonProperty("special_price", NullValueHandling = NullValueHandling.Ignore)]
    public double? SpecialPrice { get; set; }

    [JsonProperty("pichau_prices", NullValueHandling = NullValueHandling.Ignore)]
    public PichauPrices PichauPrices { get; set; }

    [JsonProperty("price_range", NullValueHandling = NullValueHandling.Ignore)]
    public PriceRange PriceRange { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public Description Description { get; set; }

    [JsonProperty("garantia", NullValueHandling = NullValueHandling.Ignore)]
    public string Garantia { get; set; }

    [JsonProperty("informacoes_adicionais", NullValueHandling = NullValueHandling.Ignore)]
    public string InformacoesAdicionais { get; set; }

    [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
    public Image Image { get; set; }

    [JsonProperty("media_gallery", NullValueHandling = NullValueHandling.Ignore)]
    public List<MediaGallery> MediaGallery { get; set; }

    [JsonProperty("short_description", NullValueHandling = NullValueHandling.Ignore)]
    public ShortDescription ShortDescription { get; set; }

    [JsonProperty("amasty_label", NullValueHandling = NullValueHandling.Ignore)]
    public AmastyLabel AmastyLabel { get; set; }

    [JsonProperty("reviews", NullValueHandling = NullValueHandling.Ignore)]
    public Reviews Reviews { get; set; }

    [JsonProperty("mysales_promotion", NullValueHandling = NullValueHandling.Ignore)]
    public MysalesPromotion MysalesPromotion { get; set; }

    [JsonProperty("only_x_left_in_stock", NullValueHandling = NullValueHandling.Ignore)]
    public object OnlyXLeftInStock { get; set; }

    [JsonProperty("stock_status", NullValueHandling = NullValueHandling.Ignore)]
    public string StockStatus { get; set; }

    [JsonProperty("codigo_barra", NullValueHandling = NullValueHandling.Ignore)]
    public string CodigoBarra { get; set; }

    [JsonProperty("codigo_ncm", NullValueHandling = NullValueHandling.Ignore)]
    public string CodigoNcm { get; set; }

    [JsonProperty("meta_title", NullValueHandling = NullValueHandling.Ignore)]
    public string MetaTitle { get; set; }

    [JsonProperty("meta_keyword", NullValueHandling = NullValueHandling.Ignore)]
    public string MetaKeyword { get; set; }

    [JsonProperty("meta_description", NullValueHandling = NullValueHandling.Ignore)]
    public string MetaDescription { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class MarcasInfo
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class MediaGallery
{
    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string Url { get; set; }

    [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
    public string Path { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public object Label { get; set; }

    [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
    public int? Position { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class MysalesPromotion
{
    [JsonProperty("expire_at", NullValueHandling = NullValueHandling.Ignore)]
    public string ExpireAt { get; set; }

    [JsonProperty("price_discount", NullValueHandling = NullValueHandling.Ignore)]
    public double? PriceDiscount { get; set; }

    [JsonProperty("price_promotional", NullValueHandling = NullValueHandling.Ignore)]
    public double? PricePromotional { get; set; }

    [JsonProperty("promotion_name", NullValueHandling = NullValueHandling.Ignore)]
    public string PromotionName { get; set; }

    [JsonProperty("promotion_url", NullValueHandling = NullValueHandling.Ignore)]
    public string PromotionUrl { get; set; }

    [JsonProperty("qty_available", NullValueHandling = NullValueHandling.Ignore)]
    public int? QtyAvailable { get; set; }

    [JsonProperty("qty_sold", NullValueHandling = NullValueHandling.Ignore)]
    public int? QtySold { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Option
{
    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    public int? Count { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public string Label { get; set; }

    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class PageInfo
{
    [JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
    public int? TotalPages { get; set; }

    [JsonProperty("current_page", NullValueHandling = NullValueHandling.Ignore)]
    public int? CurrentPage { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class PichauFaq
{
    [JsonProperty("answer", NullValueHandling = NullValueHandling.Ignore)]
    public string Answer { get; set; }

    [JsonProperty("question", NullValueHandling = NullValueHandling.Ignore)]
    public string Question { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class PichauPrices
{
    [JsonProperty("avista", NullValueHandling = NullValueHandling.Ignore)]
    public double? Avista { get; set; }

    [JsonProperty("avista_discount", NullValueHandling = NullValueHandling.Ignore)]
    public int? AvistaDiscount { get; set; }

    [JsonProperty("avista_method", NullValueHandling = NullValueHandling.Ignore)]
    public string AvistaMethod { get; set; }

    [JsonProperty("base_price", NullValueHandling = NullValueHandling.Ignore)]
    public double? BasePrice { get; set; }

    [JsonProperty("final_price", NullValueHandling = NullValueHandling.Ignore)]
    public double? FinalPrice { get; set; }

    [JsonProperty("max_installments", NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxInstallments { get; set; }

    [JsonProperty("min_installment_price", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinInstallmentPrice { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class PriceRange
{
    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class ProductLabel
{
    [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
    public string Image { get; set; }

    [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
    public string Position { get; set; }

    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public int? Size { get; set; }

    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public string Label { get; set; }

    [JsonProperty("label_color", NullValueHandling = NullValueHandling.Ignore)]
    public string LabelColor { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Products
{
    [JsonProperty("aggregations", NullValueHandling = NullValueHandling.Ignore)]
    public List<Aggregation> Aggregations { get; set; }

    [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
    public List<Item> Items { get; set; }

    [JsonProperty("page_info", NullValueHandling = NullValueHandling.Ignore)]
    public PageInfo PageInfo { get; set; }

    [JsonProperty("total_count", NullValueHandling = NullValueHandling.Ignore)]
    public int? TotalCount { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class Reviews
{
    [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
    public int? Rating { get; set; }

    [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
    public int? Count { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}

public class PichauProductData
{
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public Data Data { get; set; }
}

public class ShortDescription
{
    [JsonProperty("html", NullValueHandling = NullValueHandling.Ignore)]
    public string Html { get; set; }

    [JsonProperty("__typename", NullValueHandling = NullValueHandling.Ignore)]
    public string Typename { get; set; }
}